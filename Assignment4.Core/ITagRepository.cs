using System;
using System.Collections.Generic;

namespace Assignment4.Core
{
    public interface ITagRepository : IDisposable
    {
        
        TagDTO Create(TagCreateDTO tag);

        TagDTO Read(int TagId);

        IReadOnlyCollection<TagDTO> Read();
        
        TagDTO Update(TagCreateDTO tag);

        TagDTO Delete(TagCreateDTO tag);
        
    }
}