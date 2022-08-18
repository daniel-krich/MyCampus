using Microsoft.AspNetCore.Components.Forms;
using MyCampusUI.Models;
using System.IO.Compression;

namespace MyCampusUI.Interfaces.Services
{
    public interface IBundleFilesService
    {
        Task<bool> DeleteBundleAsync(Guid bundleId);
        Task<Guid?> CreateBundleAsync(IBrowserFile[] files, CancellationToken token = default);
        Task<bool> RewriteBundleAsync(Guid bundleId, IBrowserFile[] files, CancellationToken token = default);
        Task<ZipArchive?> ReadBundleAsync(Guid bundleId);
        Task<Stream?> OpenBundleStreamAsync(Guid bundleId);
    }
}
