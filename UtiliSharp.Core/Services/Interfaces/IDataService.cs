using System.Linq.Expressions;

public interface IDataService<T>
{
	Task<IEnumerable<T>> GetAllAsync();
	Task<T> GetByIdAsync(int id);
	Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
	Task AddAsync(T item);
	Task UpdateAsync(T item);
	Task DeleteAsync(int id);
	// ... other CRUD operations
}
