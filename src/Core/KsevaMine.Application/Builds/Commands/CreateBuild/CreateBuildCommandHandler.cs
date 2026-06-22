using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using KsevaMine.Application.Interfaces;
using KsevaMine.Domain.Entities;


// Класс CreateBuildCommandHandler обрабатывает команду CreateBuildCommand, которая предназначена для создания новой сборки Minecraft. Он реализует интерфейс IRequestHandler<CreateBuildCommand, int>, что означает, что он принимает команду CreateBuildCommand и возвращает результат типа int (идентификатор созданной сборки). В методе Handle происходит создание нового объекта Build на основе данных из команды, добавление его в базу данных через IApplicationDbContext и сохранение изменений. После успешного сохранения возвращается идентификатор новой сборки.
namespace KsevaMine.Application.Builds.Commands.CreateBuild
{
    public class CreateBuildCommandHandler : IRequestHandler<CreateBuildCommand, int>
    {
        private readonly IApplicationDbContext _db;

        public CreateBuildCommandHandler(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<int> Handle(CreateBuildCommand request, CancellationToken cancellationToken)
        {
            var build = new Build
            {
                Slug = request.Slug,
                Name = request.Name,
                MinecraftVersion = request.MinecraftVersion,
                ModLoader = request.ModLoader,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow
            };

            await _db.Builds.AddAsync(build, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken); // 

            return build.Id;
        }
    }
}
