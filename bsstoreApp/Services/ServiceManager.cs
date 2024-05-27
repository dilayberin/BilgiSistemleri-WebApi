using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBookService> _bookService;//lazy:çağırılılana kadar new lenmez,kullanılmaz.
                                                  //LAZY LOADİNG:nesneye ne zaman ihtiyacımız olursa o zaman kaydını yüklemektir
                                                  //böylece gereksiz kaynak kullanımındaan kaçınılmış olunur.
                                              //EAGER LOADİNG:nesneye dair herşeyi tek de yükleme
        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _bookService = new Lazy<IBookService>(() => new BookManager(repositoryManager));
        }
        public IBookService BookService => _bookService.Value;
    }
}
