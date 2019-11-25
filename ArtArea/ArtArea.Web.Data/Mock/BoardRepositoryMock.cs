using System.Collections.Generic;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;

namespace ArtArea.Web.Data.Mock
{
    // TODO [Andrew] add list with board models & accessors to it based on interface
    public class BoardRepositoryMock : IBoardRepository
    {
        public async Task CreateBoard(Board board)
        {
            
        }

        public async Task DeleteBoardById(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteBoardByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task GetBoardById(string id)
        {
            return new Board{
                        Id="2",
                        Name="Pirate",
                        ProjectId="2",
                        ProjectCollab="Ilya","Sergey"
            }
        }

        public async Task GetBoardByName(string name)
        {
            return new Board{
                 Id="1",
                        Name="Pirate",
                        ProjectId="1",
                        ProjectCollab="Ilya","Andrey"
            }
        }

        public async Task<IEnumerable<Board>> GetBoards()
        {
           return new[]{
                    new Board{
                        Id="1",
                        Name="Pirate",
                        ProjectId="1",
                        ProjectCollab="Ilya","Andrey"
                    },
                    new Board{
                        Id="2",
                        Name="Pirate",
                        ProjectId="2",
                        ProjectCollab="Ilya","Sergey"
                    }
        }

        public async Task UpdateBoardById(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateBoardByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}