var parts = [
	["Head", "Jaw", "TongueRear", "TongueFront", "Brain", "Scalp", "L_Eye", "R_Eye", "L_Cheek", "R_Cheek", "L_LipUpper", "R_LipUpper", "Nostrils", "L_LipLower", "R_LipLower", "L_LipCorner", "R_LipCorner", "L_EyeLidLower", "R_EyeLidLower", "L_EyeLidUpper", "R_EyeLidUpper", "L_BrowInner", "R_BrowInner", "L_BrowOuter", "R_BrowOuter"],
	["Spine0", "Spine1", "Spine2", "Spine3", "Spine4", "Spine5", "L_Clavical", "R_Clavical", "Heart", "L_Lung", "R_Lung"],
	["Stomache", "Hip"],
	["R_UpperArm0", "R_UpperArm1", "R_ForeArm0", "R_ForeArm0"],
	["L_UpperArm0", "L_UpperArm1", "L_ForeArm0", "L_ForeArm0"],
	["R_Hand", "R_Fingers", "R_Finger_Index0", "R_Finger_Index1", "R_Finger_Index2", "R_Finger_Index3", "R_Finger_Index4", "R_Finger_Middle0", "R_Finger_Middle1", "R_Finger_Middle2", "R_Finger_Middle3", "R_Finger_Middle4", "R_Finger_Ring0", "R_Finger_Ring1", "R_Finger_Ring2", "R_Finger_Ring3", "R_Finger_Ring4", "R_Finger_Pinky0", "R_Finger_Pinky1", "R_Finger_Pinky2", "R_Finger_Pinky3", "R_Finger_Pinky4", "R_Finger_Thumb0", "R_Finger_Thumb1", "R_Finger_Thumb2", "R_Finger_Thumb3", "R_Finger_Thumb4"],
	["L_Hand", "L_Fingers", "L_Finger_Index0", "L_Finger_Index1", "L_Finger_Index2", "L_Finger_Index3", "L_Finger_Index4", "L_Finger_Middle0", "L_Finger_Middle1", "L_Finger_Middle2", "L_Finger_Middle3", "L_Finger_Middle4", "L_Finger_Ling0", "L_Finger_Ling1", "L_Finger_Ling2", "L_Finger_Ling3", "L_Finger_Ling4", "L_Finger_Pinky0", "L_Finger_Pinky1", "L_Finger_Pinky2", "L_Finger_Pinky3", "L_Finger_Pinky4", "L_Finger_Thumb0", "L_Finger_Thumb1", "L_Finger_Thumb2", "L_Finger_Thumb3", "L_Finger_Thumb4"],
	["R_Thigh0", "R_Thigh1", "R_Shin0", "R_Shin1"],
	["L_Thigh0", "L_Thigh1", "L_Shin0", "L_Shin1"],
	["R_Foot", "R_Heel0", "R_Heel1", "R_Toe0", "R_Toe1"],
	["L_Foot", "L_Heel0", "L_Heel1", "L_Toe0", "L_Toe1"],
	["Neck"]
];
var prettyNames = ["head", "chest", "stomach", "right arm", "left arm", "right hand", "left hand", "right leg", "left leg", "right foot", "left foot", "neck"];
var cfg = "DeathAnnouncer";

function On_PlayerKilled(e)
{
	var bodyPart = e.DamageEvent.bodyPart.ToString();
	var msg = Data.GetConfigValue(cfg, "Message", "message");

    if (e.WeaponName != null) 
	{
		var newmsg = msg.replace("VICTIM", e.Victim.Name).replace("KILLER", e.Attacker.Name).replace("WEAPON", e.WeaponName).replace("BODYPART", getNiceName(bodyPart)).replace("DISTANCE", getDistance(e.Attacker.X, e.Attacker.Z, e.Victim.X, e.Victim.Z));
		Server.Broadcast(newmsg);
	}
}

function getNiceName(bp)
{	
	var val = "unknown";
	for (var i=0; i<12; i++)
	{
		if (contains(parts[i], bp))
		{
			val = prettyNames[i];
			break;
		}
	}
	return val;
}

function getDistance(x1, z1, x2, z2)
{
	var dx = x2-x1;
	var dz = z2-z1;
	return Math.round(Math.sqrt(dx*dx + dz*dz)) + "m";
}

function contains(a, obj) {
    var i = a.length;
    while (i--) {
       if (a[i] == obj) {
           return true;
       }
    }
    return false;
}