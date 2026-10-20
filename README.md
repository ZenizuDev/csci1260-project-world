# ZooWorld

## Questions:

1. Explain your two diamonds: The hollow diamond between Animal and Zoo shows that zoo does not make Animal, it is however passes to it (through Zoo.Add()). The filled diamond is between Animal and FeedingRecord, Animal directly creates FeedingRecord with a new() call and doesnt pass it anywher else but its own private list.
2. Justify your interface: The ICanFly interface is small, but lets you differentiate between flying and non-flying animals. If the Animal base class were to have a fly method, non flyers would need a fly method. If there was a seperate abstract class for flyers, the bat would extend both Animal->flyer, and Animal->Mammal and c# doesnt support multiple inheritence from a single class.
3. Adding a new kind: I would add a new Hawk.cs file, it inherets Animal and the ICanFly, I would have to edit the Program.cs and add a new case for the Hawk and thats it. Arguably the Animals.txt would have to change aswell.