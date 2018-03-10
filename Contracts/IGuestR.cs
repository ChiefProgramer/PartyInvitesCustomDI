namespace Contracts {
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using Entities;

	public interface IGuestR {

		Task<int> CountAsync();
		void Add(Guest aGuest);
		void Update(Guest aGuest);
		void Delete(int aGuestId);
		Task<Guest> GetAsync(int aGuestId);
		Task<List<Guest>> GetAllAsync();

	}
}