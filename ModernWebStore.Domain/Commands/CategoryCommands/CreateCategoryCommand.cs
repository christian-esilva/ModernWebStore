namespace ModernWebStore.Domain.Commands.CategoryCommands
{
    public class CreateCategoryCommand
    {
        public CreateCategoryCommand(string title)
        {
            Title = title;
        }

        public string Title { get; set; }
    }
}
