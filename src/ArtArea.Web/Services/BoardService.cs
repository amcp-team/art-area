using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Models.Privacy;
using ArtArea.Web.Data.Interface;
using ArtArea.Web.Services.Models;

namespace ArtArea.Web.Services
{
    public class BoardService
    {
        private IBoardRepository _boardRepository;
        private IPinRepository _pinRepository;
        public BoardService(IBoardRepository boardRepository,IPinRepository pinRepository)
        {
            _boardRepository = boardRepository;
            _pinRepository = pinRepository;
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

        public Task<string> CreateBoardAsync(CreateBoardModel board, string username)
        {
            if (board != null)
            {
                var num = GetNextBoardId(board.ProjectId);
                var id = board.ProjectId + "." + num;
                var newBoard = new Board
                {
                    Id = id,
                    Title = board.Title,
                    Description = board.Description,
                    ProjectId = board.ProjectId,
                    Collaborators = new List<UserAccess>(new[] {
                        new UserAccess {
                            Username = username,
                            Role = AccessRole.Admin
                        }
                    }),
                    Task = new Message(),
                    Privacy =
                        board.IntPrivacy == 0 ? BoardPrivacy.Public :
                        board.IntPrivacy == 1 ? BoardPrivacy.PublicForProjectCollabotators : BoardPrivacy.PublicForBoardCollaborators,
                    Number = num,
                    Pins = new List<string>()
                };

                return Task.Run(async () =>
                {
                    await _boardRepository.CreateBoardAsync(newBoard);
                    return id;
                });
            }
            else throw new Exception("Some board's parameters are empty");
        }

        private int GetNextBoardId(string projectId)
        {
            if (_boardRepository.ReadBoards().Any())
            {
                var projectBoards = _boardRepository.ReadBoards()
                   .Where(x => x.ProjectId == projectId);

                if (projectBoards.Any())
                {
                    return projectBoards
                        .Select(x => x.Number)
                        .Max() + 1;
                }
                else return 0;
            }
            else return 0;
        }

        public Task<List<Pin>> GetPinsAsync(string boardId)
        {
            if (BoardExists(boardId))
            {
                var pinsId = _boardRepository.ReadBoard(boardId).Pins;
                var allPins=_pinRepository.ReadPins();
                var pins = new List<Pin>();
                foreach(string id in pinsId)
                {
                    pins.Add(allPins.FirstOrDefault(x => x.Id == id));
                }
                return Task.Run(() => 
                {
                    return pins; 
                });
               


            }
            else throw new Exception("No board with this id");

        }
    }
}
