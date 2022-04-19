using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }
        public List<Content> GetAll()
        {
            return _contentDal.List();
        }

        public void Create(Content content)
        {
            _contentDal.Create(content);
        }
        public void Update(Content content)
        {
            _contentDal.Update(content);
        }

        public void Delete(Content content)
        {

            _contentDal.Delete(content);

        }
        public Content GetById(int id)
        {
            return _contentDal.GetById(x => x.ContentId == id);
        }

        public List<Content> GetListByHeadingId(int headingId)
        {
            return _contentDal.List(x=>x.HeadingId== headingId);
        }

        public List<Content> GetListByWriter(int writerId)
        {
            return _contentDal.List(x => x.WriterId == writerId);
        }
    }
}
