using Project04.Domain.Entities;

namespace Project04.Application.Tests.Infrastructure.Repositories
{
    public class DbRepositoryTest : BaseTest
    {
        [Fact]
        public void CanListUsers()
        {
            // Arrange
            DbRepository.BeginTransaction();

            // Act
            var userEntities = DbRepository.Users.ToList();

            // Assert
            Assert.NotNull(userEntities);
        }

        [Fact]
        public void CanCreateUser()
        {
            // Arrange
            DbRepository.BeginTransaction();

            // Act
            var userEntity = new UserEntity();

            DbRepository.Users.Add(userEntity);

            DbRepository.SaveChanges();

            userEntity = DbRepository.Users.FirstOrDefault();

            DbRepository.RollbackTransaction();

            // Assert
            Assert.NotNull(userEntity);
            Assert.NotNull(userEntity.Id);
        }

        [Fact]
        public void CanCreateMember()
        {
            // Arrange
            DbRepository.BeginTransaction();

            // Act
            var userEntity = new UserEntity();

            DbRepository.Users.Add(userEntity);

            DbRepository.SaveChanges();

            var memberEntity = new MemberEntity(userEntity.Id);

            DbRepository.Members.Add(memberEntity);

            DbRepository.SaveChanges();

            memberEntity = DbRepository.Members.FirstOrDefault();
            userEntity = DbRepository.Users.FirstOrDefault();

            DbRepository.RollbackTransaction();

            // Assert
            Assert.NotNull(userEntity);
            Assert.NotNull(userEntity.Id);
        }
    }
}
