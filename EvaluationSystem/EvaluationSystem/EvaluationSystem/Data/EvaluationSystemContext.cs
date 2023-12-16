using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EvaluationSystem.Models;

namespace EvaluationSystem.Data
{
    public class EvaluationSystemContext : DbContext
    {
        public EvaluationSystemContext (DbContextOptions<EvaluationSystemContext> options)
            : base(options)
        {
        }

        public DbSet<EvaluationSystem.Models.User> User { get; set; } = default!;

        public DbSet<EvaluationSystem.Models.Position> Position { get; set; }

        public DbSet<EvaluationSystem.Models.Term>? Term { get; set; }

        public DbSet<EvaluationSystem.Models.GradingPeriod>? GradingPeriod { get; set; }

        public DbSet<EvaluationSystem.Models.Evaluation>? Evaluation { get; set; }

        public DbSet<EvaluationSystem.Models.EvaluationRating>? EvaluationRating { get; set; }

        public DbSet<EvaluationSystem.Models.EvaluationCategory>? EvaluationCategory { get; set; }

        public DbSet<EvaluationSystem.Models.EvaluationDetails>? EvaluationDetails { get; set; }

        public DbSet<EvaluationSystem.Models.CommentEval>? CommentEval { get; set; }

        public DbSet<EvaluationSystem.Models.PeerEvaluation>? PeerEvaluation { get; set; }

        public DbSet<EvaluationSystem.Models.HeadEvaluation>? HeadEvaluation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EvaluationDetails>(entity =>
            {
                entity.HasOne(q => q.EvaluatedUser)
                .WithMany()
                .HasForeignKey(q => q.EvaluatedUserId);
            });

            modelBuilder.Entity<CommentEval>(entity =>
            {
                entity.HasOne(q => q.CommentedBy)
                .WithMany()
                .HasForeignKey(q => q.CommentedById);
            });
        }
    }
}
