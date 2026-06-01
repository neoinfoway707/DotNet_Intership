namespace DB_Approach_CRUD.API.Constants
{
    public static class ApiRoutes
    {
        public const string basePath = "api";
        public class Employee
        {
            public const string GetAll = basePath + "/employees";
            public const string GetById = basePath + "/employees/{id}";
            public const string CreateEmp = basePath + "/employees";
            public const string UpdateEmp = basePath + "/employees/{id}";
            public const string DeleteEmp = basePath + "/employees/{id}";
        }

        public class User
        {
            public const string Register = basePath + "/auth/register";
            public const string Login = basePath + "/auth/login";
        }
    }
}
