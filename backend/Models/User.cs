namespace backend.Models
{
    /* This is the User model, which represents a user in our system.
     * It has properties that correspond to the columns in the database.
     * It also has a PasswordHash property to store the hashed password securely.
     */
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }

        
    }
}
