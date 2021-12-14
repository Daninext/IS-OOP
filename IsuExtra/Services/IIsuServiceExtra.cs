using System.Collections.Generic;
using Isu.Services;

namespace IsuExtra.Services
{
    public interface IIsuServiceExtra : IIsuService
    {
        public CGTA AddCGTA(char megaFaculty, List<GroupExtra> groups = null);
        public void SingUpForCGTA(CGTA cgta, StudentExtra student);
        public void RemoveFromCGTA(CGTA cgta, StudentExtra student);
        public CGTA FindCGTA(char megaFaculty);
        public IReadOnlyList<StudentExtra> GetStudentsFromCGTA(CGTA cgta);
        public IReadOnlyList<StudentExtra> FindFreeStudents(GroupExtra group);
    }
}
