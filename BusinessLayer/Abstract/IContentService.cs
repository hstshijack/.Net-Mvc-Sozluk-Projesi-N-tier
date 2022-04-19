using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetAll();
        List<Content> GetListByHeadingId(int headingId);
        List<Content> GetListByWriter(int writerId);
        void Create(Content content);
        Content GetById(int id);
        void Delete(Content content);
        void Update(Content content);
    }
}
