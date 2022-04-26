using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class CreateToDoCommand : Notifiable, ICommand
    {
        public CreateToDoCommand()
        {
        }

        public CreateToDoCommand(string title, DateTime date, string user)
        {
            this.Title = title;
            this.Date = date;
            this.User = user;

        }

        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Title, 3, "Title", "Por favor, descreva melhor esta tarefa !")
                    .HasMinLen(User, 6, "User", "Usuário invalido")
            );
        }
    }
}