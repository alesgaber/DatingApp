using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly DataContext _context;
        public PhotoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Photo> GetPhotoById(int photoId)
        {
            return await _context.Photos
            .IgnoreQueryFilters()
            .SingleOrDefaultAsync(x => x.Id == photoId);
        }

        public async Task<IEnumerable<PhotoForApprovalDto>> GetUnapprovedPhotos()
        {
            return await _context.Photos
                .IgnoreQueryFilters()
                .Where(p => p.IsApproved == false)
                .Select(x => new PhotoForApprovalDto
                {
                    Id = x.Id,
                    IsApproved = x.IsApproved,
                    Username = x.AppUser.UserName,
                    Url = x.Url
                })
                .ToListAsync();
        }

        public void RemovePhoto(Photo photo)
        {
            _context.Photos.Remove(photo);
        }
    }
}