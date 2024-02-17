using TodoList_Models;
using TodoListModels;

namespace TodoList_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SetProperties_ShouldSetCorrectly()
        {
            // Arrange
            var to_do_item = new TodoItem();

            // Act
            to_do_item.Id = 1;
            to_do_item.Description_of_Todo = "description";
            to_do_item.Completed_Date = DateTime.Now;

            // Assert
            Assert.AreEqual(1, to_do_item.Id);
            Assert.AreEqual("description", to_do_item.Description_of_Todo);
            Assert.IsNotNull(to_do_item.Completed_Date);
        }

        [TestMethod]
        public void Id_DefaultValue_ShouldBeZero()
        {
            // Arrange
            var to_do_item = new TodoItem();

            // Assert
            Assert.AreEqual(0, to_do_item.Id);
        }  

        [TestMethod]
        public void DescriptionpfDefaultValue_ShouldBeNull()
        {
            // Arrange
            var to_do_item = new TodoItem();

            // Assert
            Assert.IsNull(to_do_item.Description_of_Todo);
        } 

        [TestMethod]
        public void CompletedDateofDefaultValue_ShouldBeNull()
        {
            // Arrange
            var to_do_item = new TodoItem();

            // Assert
            Assert.IsNull(to_do_item.Completed_Date);
        }
    }
}