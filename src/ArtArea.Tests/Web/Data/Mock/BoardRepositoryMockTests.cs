using System;
using System.Linq;
using System.Threading.Tasks;
using ArtArea.Models;
using ArtArea.Web.Data.Interface;
using ArtArea.Web.Data.Mock;
using Xunit;
[assembly: CollectionBehavior(
    CollectionBehavior.CollectionPerAssembly,
    MaxParallelThreads = 1,
    DisableTestParallelization = true)]

namespace ArtArea.Tests.Web.Data.Mock
{
    public class BoardRepositoryMockTests
    {
        private IBoardRepository _repository = new BoardRepositoryMock();

        #region Read Tests

        [Fact]
        public async Task Test_ReadBoards()
        {
            var boards = await _repository.ReadBoardsAsync();

            Assert.Equal(boards, ApplicationDbMock.Boards);
        }

        [Fact]
        public async Task Test_ReadBoard_Success()
        {
            var boardId = ApplicationDbMock.Boards.FirstOrDefault().Id;
            var board = await _repository.ReadBoardAsync(boardId);

            Assert.Equal(board.Id, boardId);
        }

        [Fact]
        public async Task Test_ReadBoard_Fail()
        {
            var board = await _repository.ReadBoardAsync(Guid.NewGuid().ToString());

            Assert.Null(board);
        }

        #endregion

        #region Create Tests

        [Fact]
        public async Task Test_CreateBoard_Success()
        {
            var newBoard = new Board
            {
                Id = "1234"
            };

            await _repository.CreateBoardAsync(newBoard);

            Assert.Contains(ApplicationDbMock.Boards, x => x.Id == newBoard.Id);

            ApplicationDbMock.Initialize();
        }

        [Fact]
        public async Task Test_CreateBoard_Fail()
        {
            await Assert.ThrowsAnyAsync<Exception>(
                new Func<Task>(() => _repository.CreateBoardAsync(ApplicationDbMock.Boards.FirstOrDefault())));
        }

        #endregion

        #region Delete Tests

        [Fact]
        public async Task Test_DeleteBoard_Success()
        {
            var boardToDeleteId = ApplicationDbMock.Boards.FirstOrDefault().Id;

            await _repository.DeleteBoardAsync(boardToDeleteId);

            Assert.DoesNotContain(ApplicationDbMock.Boards, x => x.Id == boardToDeleteId);

            ApplicationDbMock.Initialize();
        }

        [Fact]
        public async Task Test_DeleteBoard_Fail()
        {
            await Assert.ThrowsAnyAsync<Exception>(new Func<Task>(() => _repository.DeleteBoardAsync("")));
        }

        #endregion

        #region Update Tests

        [Fact]
        public async Task Test_UpdateBoard_Success()
        {
            var boardToUpdate = ApplicationDbMock.Boards.FirstOrDefault();

            boardToUpdate.Description = "1234";

            await _repository.UpdateBoardAsync(boardToUpdate);

            Assert.Equal("1234", ApplicationDbMock.Boards.SingleOrDefault(x => x.Id == boardToUpdate.Id).Description);
        }

        [Fact]
        public async Task Test_UpdateBoard_Fail()
        {
            await Assert.ThrowsAnyAsync<Exception>(
                new Func<Task>(() => _repository.UpdateBoardAsync(new Board { Id = "" })));
        }

        #endregion
    }
}