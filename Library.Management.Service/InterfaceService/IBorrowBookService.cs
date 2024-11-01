using Library.Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Management.Service.InterfaceService
{
    public interface IBorrowBookService
    {
        Task BorrowAddAsync(BorrowRecord entity);
		Task<ReturnView> GetBorrowRecordForReturnAsync(int borrowRecordId);
        Task ReturnBookAsync(int borrowRecordId);
	}
}
