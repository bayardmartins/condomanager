namespace CondoManager.Business
{
    public class ResidentBusiness
    {
        private char[] phoneFilter = {' ','-','(',')'};
        private char[] cpfFilter = {'.',',','-',' '};
        public Resident CreateResident(Resident resident)
        {
            Resident newResident = resident;
            newResident.Phone = resident.Phone.Trim(phoneFilter);
            newResident.Cpf = resident.Cpf.Trim(cpfFilter);
            
            return newResident;
        }
    }
}