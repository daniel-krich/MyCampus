using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using MyCampusData.Data;
using MyCampusData.Entities;
using MyCampusUI.Interfaces.Services;
using MyCampusUI.Models;
using System.IO.Compression;

namespace MyCampusUI.Services
{
    public class BundleFilesService : IBundleFilesService
    {
        public static string BundleRelativeDirectory { get; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bundle-uploads");
        public static long MaxFileSize { get; } = 1024 * 1000 * 15;        

        private readonly IDbContextFactory<CampusContext> _campusContextFactory;
        public BundleFilesService(IDbContextFactory<CampusContext> campusContextFactory)
        {
            _campusContextFactory = campusContextFactory;
            Directory.CreateDirectory(BundleRelativeDirectory);
        }

        public async Task<Guid?> CreateBundleAsync(params IBrowserFile[] files)
        {
            if(files.Sum(x => x.Size) > MaxFileSize || files.Any(x => x.Size > MaxFileSize)) return default;

            using (var dbContext = await _campusContextFactory.CreateDbContextAsync())
            {
                try
                {
                    var bundle = new BundleFileEntity
                    {
                        BundleFiles = files.Length,
                        BundleSize = files.Sum(f => f.Size)
                    };
                    dbContext.Bundles.Add(bundle);

                    using (var bundleFile = new FileStream(Path.Combine(BundleRelativeDirectory, bundle.Id.ToString()), FileMode.CreateNew, FileAccess.Write, FileShare.None))
                    {
                        using ZipArchive archive = new ZipArchive(bundleFile, ZipArchiveMode.Create);
                        foreach (var file in files)
                        {
                            try
                            {
                                using var fileStream = file.OpenReadStream(MaxFileSize);

                                var entry = archive.CreateEntry(file.Name);
                                using var entryStream = entry.Open();
                                await fileStream.CopyToAsync(entryStream);
                            }
                            catch { }
                        }
                    }

                    await dbContext.SaveChangesAsync();

                    return bundle.Id;
                }
                catch (Exception)
                {
                }
            }
            return default;
        }

        public async Task<bool> DeleteBundleAsync(Guid bundleId)
        {
            using (var dbContext = await _campusContextFactory.CreateDbContextAsync())
            {
                try
                {
                    File.Delete(Path.Combine(BundleRelativeDirectory, bundleId.ToString()));

                    var bundle = await dbContext.Bundles.FindAsync(bundleId);
                    if (bundle != null)
                    {
                        dbContext.Bundles.Remove(bundle);
                        await dbContext.SaveChangesAsync();
                        return true;
                    }
                    return false;
                }
                catch (Exception)
                {
                }
            }
            return false;
        }

        public async Task<ZipArchive?> ReadBundleAsync(Guid bundleId)
        {
            using (var dbContext = await _campusContextFactory.CreateDbContextAsync())
            {
                try
                {
                    var bundle = await dbContext.Bundles.FindAsync(bundleId);
                    if (bundle != null)
                    {
                        var bundleFile = new FileStream(Path.Combine(BundleRelativeDirectory, bundle.Id.ToString()), FileMode.Open, FileAccess.Read, FileShare.Read);
                        ZipArchive archive = new ZipArchive(bundleFile, ZipArchiveMode.Read);
                        return archive;
                    }
                }
                catch (Exception)
                {
                    return default;
                }
            }
            return default;
        }

        public async Task<Stream?> OpenBundleStreamAsync(Guid bundleId)
        {
            using (var dbContext = await _campusContextFactory.CreateDbContextAsync())
            {
                try
                {
                    var bundle = await dbContext.Bundles.FindAsync(bundleId);
                    if (bundle != null)
                    {
                        var bundleFile = new FileStream(Path.Combine(BundleRelativeDirectory, bundle.Id.ToString()), FileMode.Open, FileAccess.Read, FileShare.Read);
                        return bundleFile;
                    }
                }
                catch (Exception)
                {
                    return default;
                }
            }
            return default;
        }

        public async Task<bool> RewriteBundleAsync(Guid bundleId, params IBrowserFile[] files)
        {
            if (files.Sum(x => x.Size) > MaxFileSize || files.Any(x => x.Size > MaxFileSize)) return false;

            using (var dbContext = await _campusContextFactory.CreateDbContextAsync())
            {
                try
                {
                    var bundle = await dbContext.Bundles.FindAsync(bundleId);
                    if(bundle != null)
                    {
                        bundle.BundleFiles = files.Length;
                        bundle.BundleSize = files.Sum(x => x.Size);
                        bundle.ModifiedAt = DateTime.Now;
                        dbContext.Bundles.Update(bundle);

                        string bundlePath = Path.Combine(BundleRelativeDirectory, bundle.Id.ToString());
                        FileMode fileMode = File.Exists(bundlePath) ? FileMode.Truncate : FileMode.CreateNew;

                        using (var bundleFile = new FileStream(bundlePath, fileMode, FileAccess.Write, FileShare.None))
                        {
                            using ZipArchive archive = new ZipArchive(bundleFile, ZipArchiveMode.Create);
                            foreach (var file in files)
                            {
                                try
                                {
                                    using var fileStream = file.OpenReadStream(MaxFileSize);

                                    var entry = archive.CreateEntry(file.Name);
                                    using var entryStream = entry.Open();
                                    await fileStream.CopyToAsync(entryStream);
                                }
                                catch { }
                            }
                        }
                        await dbContext.SaveChangesAsync();

                        return true;
                    }
                }
                catch(Exception)
                {
                }
            }
            return false;
        }
    }
}
