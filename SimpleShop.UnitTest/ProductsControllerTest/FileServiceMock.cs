using Moq;
using SimpleShop.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.UnitTest.ProductsControllerTest
{
    public static class FileServiceMock
    {
        public static IFilesService FilesService ()
        {
            var filesService = Mock.Of<IFilesService>();

            return filesService;
        }
    }
}
