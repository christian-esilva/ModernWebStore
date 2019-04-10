namespace ModernWebStore.Domain.Commands.CategoryCommands
{
    public class UpdateCategoryCommand
    {
        public UpdateCategoryCommand(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public int Id { get; set; }
        public string Title { get; set; }
    }
}
