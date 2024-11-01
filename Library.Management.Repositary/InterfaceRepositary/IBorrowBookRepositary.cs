using Library.Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Management.Repositary.InterfaceRepositary
{
    public interface IBorrowBookRepositary
    {
        Task BorrowAddAsync(BorrowRecord entity);
        Task<BorrowRecord> GetBorrowRecordByIdAsync(int id);
		Task UpdateBorrowRecordAsync(BorrowRecord borrowRecord);
	}
}
