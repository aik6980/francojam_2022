INCLUDE PlayerState.ink

/*
VAR betsy_likes_dogs=2
VAR betsy_likes_cats=10
VAR betsy_likes_kids=5
VAR betsy_likes_walks=5
VAR betsy_smart=7
VAR betsy_active=3
VAR betsy_playful=4
*/
VAR affinity=4

-> round_1

=== round_1 ===
Howdy, stranger! The name's Betsy. #Name_Betsy
Mighty kind of you to drop by. #Name_Betsy
You're speaking to the finest belle this side of the Arun! #Name_Betsy
*[Howdy]And a howdy right back to you! #Name_Me

-That's the spirit, hun! #Name_Betsy
Tell me, stranger, so we might not be strangers no more: #Name_Betsy
How'dya like ~fashion~? #Name_Betsy
*{active < 5}[Form over function]Gotta dress to impress! #Name_Me
Oh ain't that the truth, partner! #Name_Betsy
~affinity = affinity + 2
*[Does it matter?]I don't really pay attention to it... #Name_Me
Trust me hun, I can tell. #Name_Betsy
~affinity = affinity - 2
*[Function over form]I wear what's appropriate to the situation. Can't go for a hike in heels, can you? #Name_Me
Nothin' wrong with that! #Name_Betsy

- -> DONE

=== round_2 ===
Fancy seeing you 'round these parts! #Name_Betsy
Glad to have ya back in town. #Name_Betsy
Whatcha think of today's look? #Name_Betsy
*[Fabulous as always]You're looking fabulous, and I expect nothing less! #Name_Me

-Hoho, there's that southern charm! #Name_Betsy
Ya just caught me readin' 'bout your beautiful country's history... #Name_Betsy
Yer ancestors certainly had an eye for architecture! You got a favourite type? #Name_Betsy
*[Nope]As long as it's got four walls and a roof, I'm content. #Name_Me
Heavens above, you gotta take pride in yer heritage! #Name_Betsy
~affinity = affinity - 2
*[Castles]Can't go wrong with the old castles! #Name_Me
Ain't they just the prettiest things? #Name_Betsy
*{smart >= 7}[Can't pick just one]It's impossible to pick just one! Everything from the great Gothic cathedrals to the peasant's wattle and daub! #Name_Me
Oh I just know I could rack your brains for hours, partner! #Name_Betsy
~affinity = affinity + 2

- -> DONE

=== round_3 ===
Look what the cat dragged in! #Name_Betsy
Aw, I'm jus' teasin' you, partner. #Name_Betsy
{affinity > 7: It's a fine day with you around! | ...or am I?} #Name_Betsy
*[Cat? Here?]I can't imagine a cat dragging anything around here! #Name_Me

-You're quite right, and it's a darn shame. #Name_Betsy
I've long admired the effort cats put into their appearance. #Name_Betsy
So elegant... so refined! #Name_Betsy
*[They're fine]Of all the animals in the world, they're certainly some of them. #Name_Me
You'll learn to love 'em, I jus' know it! #Name_Betsy
->END
*{likes_cats >= 7}[They're beautiful]Magnificent creatures, aren't they? I bet you inspire them right back! #Name_Me
Aw shucks, wouldn't that be sweet? #Name_Betsy
~affinity = affinity + 2
->END
*{likes_cats < 7}[They're not my cup of tea]You think so? I'm not the biggest fan. #Name_Me
The feelin's prob'ly mutual. More reason to like 'em, I reckon. #Name_Betsy
~affinity = affinity - 2
->END