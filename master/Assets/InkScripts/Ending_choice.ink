VAR dog_names = "Otis"
VAR back_to_selection = 1

-> end_1

=== end_1 ===
It has been years since you had { dog_names }. 
We have many good memory together, but there are still many others at the center
Thinking of visiting Holbrook Animal Rescue for another dog?
	*[Let's go find another dog] Let's go find another dog #Name_Me
	~back_to_selection = 1
    *[I'm not sure] I'm not sure #Name_Me
	~back_to_selection = 0
	
- -> END