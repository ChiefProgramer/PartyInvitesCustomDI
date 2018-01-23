namespace Entities
{

	public class Guest : IGuest { //could call this PartyGuest

		public IGuest ShallowCopy() {
			return (Guest)this.MemberwiseClone(); //This lets us avoid needing DI in the Repo
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public bool? WillAttend { get; set; }

		public override string ToString() {
			return "'" + Name + "','" + Email + "','" + Phone + "','" + WillAttend.ToString() +  "'";
			
		}

	}
}