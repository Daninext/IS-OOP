using Isu.Services;
using Isu.Tools;
using NUnit.Framework;

namespace Isu.Tests
{
    public class Tests
    {
        private IIsuService _isuService;

        [SetUp]
        public void Setup()
        {
            //TODO: implement
            _isuService = null;
        }

        [Test]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            _isuService = new IsuService();
            _isuService.AddGroup("M3204");
            _isuService.AddStudent(_isuService.FindGroup("M3204"), "Artem");

            Assert.IsTrue(_isuService.FindStudent("Artem").MyGroup.Students.Contains(_isuService.FindStudent("Artem")));
        }

        [Test]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            Assert.Catch<IsuException>(() =>
            {
                _isuService = new IsuService();
                _isuService.AddGroup("M3204");

                // Add "Artem" 25 times in the group 
                for (int i = 0; i < 25; ++i)
                    _isuService.AddStudent(_isuService.FindGroup("M3204"), "Artem");

                // Add "Artem" one more time and get error
                _isuService.AddStudent(_isuService.FindGroup("M3204"), "Artem");
            });
        }

        [Test]
        public void CreateGroupWithInvalidName_ThrowException()
        {
            Assert.Catch<IsuException>(() =>
            {
                _isuService = new IsuService();
                _isuService.AddGroup("Mda92");
            });
        }

        [Test]
        public void TransferStudentToAnotherGroup_GroupChanged()
        {
            _isuService = new IsuService();
            _isuService.AddGroup("M3204");
            _isuService.AddGroup("M3205");
            _isuService.AddStudent(_isuService.FindGroup("M3204"), "Artem");
            _isuService.ChangeStudentGroup(_isuService.FindStudent("Artem"), _isuService.FindGroup("M3205"));

            Assert.IsFalse(_isuService.FindGroup("M3204").Students.Contains(_isuService.FindStudent("Artem")));
        }
    }
}