using TaskBoard.DTO;

namespace TaskBoard.Services.Interfaces
{
    public interface ITaskService
    {
        public List<TaskDto> ObterTarefas();
        public TaskDto AdicionarTarefa(TaskDto taskDto);
        public TaskDto AtualizarTarefa();
        public void RemoverTarefa();

        public void MudarStatusTarefa(bool status);

    }
}
