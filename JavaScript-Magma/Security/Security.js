var Security = {
	Name:		"Security",
	Author:		"balu92",
	Version:	"1.0.1",
	VersionNum:	1.01
};

(function(){
	var abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzA";
	var cba = "zyxwvutsrqponmlkjihgfedcabZYXWVUTSRQPONMLKJIHGFEDCABz";
	
	Security.Encrypt = function(string, mode, key, letters){
		switch(letters){case "abc": letters = abc; break; case "cba": letters = cba; break;}
		switch(mode){
			case "b64":
				return System.Convert.ToBase64String(System.Text.Encoding.Unicode.GetBytes(string));
			break;
			case "vc":
				var a = "";
				var b,c;
				var out = removeEqualSign([string, a]);
				string = out[0]; a = out[1];
				var code = key;
				var n='';
				while(string.length > code.length){
					code += key;
				}
				for(var i = 0; i < string.length; i++){
					b = letters.indexOf(string[i]);
					c = letters.indexOf(code[i]);
					n+=letters[(b+c)>52?b+c-52:b+c];
				}
				return n+a;
			break;
		}
	};
	Security.Decrypt = function(secret, mode, key, letters){
		switch(letters){case "abc": letters = abc; break; case "cba": letters = cba; break;}
		switch(mode){
			case "b64":
				return System.Text.Encoding.Unicode.GetString(System.Convert.FromBase64String(secret));
			break;
			case "vc":
				var a = "";
				var b,c;
				var out = removeEqualSign([secret, a]);
				secret = out[0]; a = out[1];
				var code = key;
				var n='';
				while(secret.length > code.length){
					code += key;
				}
				for(var i = 0; i < secret.length; i++){
					b = letters.indexOf(secret[i]);
					c = letters.indexOf(code[i]);
					n+=letters[(b-c)<0?b+52-c:b-c];
				}
				return n+a;
			break;
		}
	};
	Security.ShiftLeft = function(string, shift){
		var a = "";
		var out = removeEqualSign([string, a]);
		string = out[0]; a = out[1];
		return string.substring(shift, string.length) + string.substring(0, shift)+a;
	};
	Security.ShiftRight = function(string, shift){
		var a = "";
		var out = removeEqualSign([string, a]);
		string = out[0]; a = out[1];
		return string.substring(string.length - shift, string.length) + string.substring(0, string.length - shift)+a;
	};
	
	function removeEqualSign(input){
		if(input[0].indexOf("===") != -1){
			input[1] = "===";
			input[0] = input[0].replace("===", "");
		} else if (input[0].indexOf("==") != -1){
			input[1] = "==";
			input[0] = input[0].replace("==", "");
		} else if(input[0].indexOf("=") != -1){
			input[1] = "=";
			input[0] = input[0].replace("=", "");
		}
		return input;
	};

}());

// FIXME: b64 seem to throw an error if (string.length < 6) probably some junk char at the end should do, that nobody would ever use