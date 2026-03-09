namespace backend.DTO
{
    /* A DTO is like a messenger.
     * It only carries what’s needed to someone else,
     * like sending a note instead of the whole blueprint(model).
     */
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
