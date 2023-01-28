
function On_EntityDecay(de) {
	var entityName = 'unknown';
	var isDeployable = 'unknown';
	var isStructure = 'unknown';
	var owner = 'unknown';
	var health = 'unknown';
	var info = '';
	try {
		entityName = de.Entity.Name;
		isDeployable = de.Entity.IsDeployableObject();
		isStructure = de.Entity.IsStructure();
		owner = de.Entity.OwnerID;
		health = de.Entity.Health;
	} catch(err) {
		entityName = 'err.name';
	}
	info += 'entity=' + entityName + ' owner=' + owner + ' health=' + health;
	info += ' deployable=' + isDeployable + ' structure=' + isStructure;
	Plugin.Log('DecayEvents', info);
}
