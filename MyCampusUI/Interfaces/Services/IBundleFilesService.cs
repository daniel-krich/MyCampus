using Microsoft.AspNetCore.Components.Forms;
using MyCampusUI.Models;
using System.IO.Compression;

namespace MyCampusUI.Interfaces.Services
{
    public interface IBundleFilesService
    {
        Task<bool> DeleteBundleAsync(Guid bundleId);
        Task<Guid?> CreateBundleAsync(params IBrowserFile[] files);
        Task<bool> RewriteBundleAsync(Guid bundleId, params IBrowserFile[] files);
        Task<ZipArchive?> ReadBundleAsync(Guid bundleId);
        Task<Stream?> OpenBundleStreamAsync(Guid bundleId);
    }
}
