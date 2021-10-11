using System;
using System.Collections.Generic;
using Assignment4.Core;
using System.Linq;

namespace Assignment4.Entities
{
    public class TagRepository : ITagRepository
    {

        private readonly IKanbanContext _context;

        public TagRepository(IKanbanContext context)
        {
            _context = context;
        }

        public TagDTO Create(TagCreateDTO tag)
        {
            var entity = new Tag { Name = tag.Name };

            _context.Tags.Add(entity);

            _context.SaveChanges();

            return new TagDTO(entity.Id, entity.Name);
        }

        public void Dispose()
        {

        }

        public TagDTO Read(int tagId)
        {
            var tags = from t in _context.Tags
                where t.Id == tagId
                select new TagDTO(t.Id, t.Name);

            return tags.FirstOrDefault();
        }

        public IReadOnlyCollection<TagDTO> Read()
        {
            throw new NotImplementedException();
        }

        public TagDTO Update(TagCreateDTO tag)
        {
            throw new NotImplementedException();

        }

        public TagDTO Delete(TagCreateDTO tag)
        {
            throw new NotImplementedException();
        }
        

    }

    
}