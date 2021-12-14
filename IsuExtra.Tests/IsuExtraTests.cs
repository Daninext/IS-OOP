using NUnit.Framework;
using IsuExtra.Services;
using IsuExtra.Tools;

namespace IsuExtra.Tests
{
    public class IsuExtraTests
    {
        [Test]
        public void AddNewCGTA_CheckIt()
        {
            var _isuServiceExtra = new IsuServiceExtra();

            CGTA group = _isuServiceExtra.AddCGTA('M');

            Assert.AreEqual(group, _isuServiceExtra.AddCGTA('M'));
            Assert.IsFalse(_isuServiceExtra.FindCGTA('M') == null);
        }

        [Test]
        public void SingUp_RemoveNewStudentOn_FromCGTA()
        {
            var _isuServiceExtra = new IsuServiceExtra();

            _isuServiceExtra.AddCGTA('M');

            StudentExtra stud1 = _isuServiceExtra.AddStudent(_isuServiceExtra.AddGroup("M3204"), "Artem");
            StudentExtra stud2 = _isuServiceExtra.AddStudent(_isuServiceExtra.AddGroup("N3204"), "Danil");

            _isuServiceExtra.AddGroupInCGTA(_isuServiceExtra.FindCGTA('M'), "00001");

            Assert.Catch<InvalidStudentCGTADataIsuExtraException>(() =>
            {
                _isuServiceExtra.SingUpForCGTA(_isuServiceExtra.FindCGTA('M'), stud1);
            });

            _isuServiceExtra.SingUpForCGTA(_isuServiceExtra.FindCGTA('M'), stud2);

            Assert.IsTrue(_isuServiceExtra.FindStudentsFromCGTA(_isuServiceExtra.FindCGTA('M')).Count != 0);

            _isuServiceExtra.RemoveFromCGTA(_isuServiceExtra.FindCGTA('M'), stud2);

            Assert.IsTrue(_isuServiceExtra.FindStudentsFromCGTA(_isuServiceExtra.FindCGTA('M')).Count == 0);
        }

        [Test]
        public void GetGroupsFromCGTA()
        {
            var _isuServiceExtra = new IsuServiceExtra();

            _isuServiceExtra.AddCGTA('M');

            _isuServiceExtra.AddGroupInCGTA(_isuServiceExtra.FindCGTA('M'), "00001");

            Assert.AreEqual(_isuServiceExtra.FindCGTA('M').Groups.Count, 1);
            Assert.AreEqual(_isuServiceExtra.FindCGTA('M').Groups[0].Name, "00001");
        }

        [Test]
        public void WorkWithStudents()
        {
            var _isuServiceExtra = new IsuServiceExtra();

            _isuServiceExtra.AddCGTA('M');

            StudentExtra stud1 = _isuServiceExtra.AddStudent(_isuServiceExtra.AddGroup("N3204"), "Danil");

            _isuServiceExtra.AddGroupInCGTA(_isuServiceExtra.FindCGTA('M'), "00001");
            _isuServiceExtra.SingUpForCGTA(_isuServiceExtra.FindCGTA('M'), stud1);

            Assert.AreEqual(_isuServiceExtra.FindStudentsFromCGTA(_isuServiceExtra.FindCGTA('M')).Count, 1);
            Assert.AreEqual(_isuServiceExtra.FindStudentsFromCGTA(_isuServiceExtra.FindCGTA('M'))[0].Name, "Danil");

            _isuServiceExtra.AddStudent(_isuServiceExtra.FindGroup("N3204"), "Misha");

            Assert.AreEqual(_isuServiceExtra.FindFreeStudents(_isuServiceExtra.FindGroup("N3204")).Count, 1);
            Assert.AreEqual(_isuServiceExtra.FindFreeStudents(_isuServiceExtra.FindGroup("N3204"))[0].Name, "Misha");
        }
    }
}
