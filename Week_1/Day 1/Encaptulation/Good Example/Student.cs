
namespace Week_1.Day_1.Encaptulation.Good_Example;

public class Student
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    private readonly List<string> _courses = new();

    // list must be readonly to prevent external modification
    public IReadOnlyList<string> Courses => _courses.AsReadOnly();

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > 100)
        {
            throw new ArgumentException("Name cannot be empty or exceed 100 characters.");
        }
        Name = name;
    }

    public void SetAge(int age)
    {
        if (age < 5 || age > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(age));
        }
        Age = age;
    }

    public void EnrollCourse(string course)
    {
        if (string.IsNullOrWhiteSpace(course))
        {
            throw new ArgumentException("Course cannot be empty.");
        }
        _courses.Add(course);
    }

    public void RemoveCourse(string course)
    {
        if (!_courses.Remove(course))
        {
            throw new InvalidOperationException("Course not found.");
        }
    }
}
