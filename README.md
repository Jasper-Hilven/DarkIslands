# Dark islands
A unity project with a strong focus on 
1. Making Components that exist of other reusable components
2. Trying to be more independent of unity.

GameObjects and their components are replaced by a similar structure, call these DIObjects and DIComponents. Code generation is used for this similar approach.

Each DIObject has a list of properties. One can register to the changes of each property. Each DIComponent is **responsible for maintaining one property** of its parent DIGameObject. A DIComponent can do this by registering to the changes of the properties of its parent DIGameObject.

### Conclusion
It is very easy to add new objects to the game by using the same DIGameObject. For example, A mushroom is an object of the same class as the player object, just with an other configuration. Abstracting Unity out of the project and not using GameObjects comes with a certain cost. The codegeneration goes well. 

