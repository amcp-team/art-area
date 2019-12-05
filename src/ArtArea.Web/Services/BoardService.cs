using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;

namespace ArtArea.Web.Services
{
    public class BoardService
    {
        private IBoardRepository _boardRepository;
        public BoardService(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public bool BoardExists(string boardId)
            => _boardRepository.ReadBoard(boardId) != null;

        public Task<Board> GetBoardAsync(string boardId)
        {
            if (BoardExists(boardId))
            {
                return _boardRepository.ReadBoardAsync(boardId);
            }
            else throw new Exception("No board with this id");

        }
        

      
    }
}
