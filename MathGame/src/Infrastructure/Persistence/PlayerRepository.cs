using MathGame.src.Application.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.src.Infrastructure.Persistence;

public class PlayerRepository : BaseRepository<Player, Guid>, IPlayerRepository
{
    public PlayerRepository(SQLiteAsyncConnection context) : base(context)
    {

    }
}
