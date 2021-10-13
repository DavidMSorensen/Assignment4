using System;
using System.Collections.Generic;
using Assignment4.Core;
using System.Linq;

namespace Assignment4.Entities
{
    public class TagRepository : ITagRepository
    {

        private readonly KanbanContext _context;

        public TagRepository(KanbanContext context)
        {
            _context = context;
        }

        public (Response Response, int TagId) Create(TagCreateDTO tag)
        {
            var entity = new Tag { Name = tag.Name };

            _context.Tags.Add(entity);

            _context.SaveChanges();

            var _tag = new TagDTO(entity.Id, entity.Name);

            return (Response.Created, _tag.Id);
        }

        public IReadOnlyCollection<TagDTO> ReadAll()
        {
            throw new NotImplementedException();
        }

        public TagDTO Read(int tagId)
        {
            var tags = from t in _context.Tags
                where t.Id == tagId
                select new TagDTO(t.Id, t.Name);

            return tags.FirstOrDefault();
        }

        public Response Update(TagUpdateDTO tag)
        {
            throw new NotImplementedException();

        }

        public Response Delete(int tagId, bool force = false)
        {
            throw new NotImplementedException();
        }
    }

    
}