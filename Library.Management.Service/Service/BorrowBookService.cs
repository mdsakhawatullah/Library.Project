using Library.Management.Models;
using Library.Management.Repositary.InterfaceRepositary;
using Library.Management.Service.InterfaceService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Management.Service.Service
{
    public class BorrowBookService : IBorrowBookService
    {
        private readonly IBorrowBookRepositary _BorrowBookRepositary;
        public BorrowBookService(IBorrowBookRepositary BorrowBookRepositary)
        {
            _BorrowBookRepositary = BorrowBookRepositary;
            
        }
        public Task BorrowAddAsync(BorrowRecord entity)
        {
            return _BorrowBookRepositary.BorrowAddAsync(entity);
        }
       public async Task<ReturnView> GetBorrowRecordForReturnAsync(int borrowId)
        {
            var borrowRecord = await _BorrowBookRepositary.GetBorrowRecordByIdAsync(borrowId);
            if(borrowRecord == null)
            {
                throw new Exception("No borrowRecord found for this id");
            }
			if (borrowRecord.ReturnDate !=null)
			{
				throw new InvalidOperationException($"The borrow record for {borrowRecord.LibraryBook.Title} has already been returned.");
            }
            return new ReturnView
            {
                BorrowRecordId = borrowRecord.BorrowRecordId,
                BookTitle = borrowRecord.LibraryBook.Title,
                BorrowerName = borrowRecord.BorrowerName,
                BorrowDate = borrowRecord.BorrowDate
            };

        }
    }
}
