namespace Contracts {
	using System.Collections.Generic;
	using Entities;

	public interface IGuestR {

		int Count();
		void Add(IGuest aGuest);
		void Update(IGuest aGuest);
		void Delete(int aGuestId);
		IGuest Get(int aGuestId);
		List<IGuest> GetAll();

	}
}