	############################
	ROLE CONFIGURATION 
	Only needed for staff 
	(Administrator Permissions)
	############################

	Essentially it looks something like this (without the {}):
	---- NOT CASE SENSITIVE ----

	{RoleName}:{RoleId}\{comma seperated permission list};{Another set}

	so for exmaple

	owner:123456789\*;moderator:234567891\kick,mute,ban;

	List of possible permissions (not case sensitive):
		- * (essentially star just means able to do everything - No restrictions)
		- kick (!kick)
		- ban  (!ban)
		- tempban (!tempban)
		- mute    (!mute)
		- tempmute (!mute)
		- viewhistory (!history)