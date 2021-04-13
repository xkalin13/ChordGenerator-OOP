# Functionality of generator
### Mod selector
From mod selector u can choose a variety of cadence otherwise known as chord progression.
For example

* `Cliche` + `major` - `I V vi IV`

### Scale
From scale you can choose major or minor as mentioned above.

### Key
Choose from basic notes C-D-E-F-G-A-H

### Special modifiers
These modifiers specify if note is halftone up or down e.g. C# or Db

# How it's done ?
* User input - Based on user chosen values, this program decides a path which a progression chords follow. To achieve good sounding harmonized chords - programme uses a specific procedures - see logic below.
* Random - This method generates a few progressions by using this formula with random pick of the path the progression is going.

## Circle of fifths
This is a special circle made by fifts and fourths- this determines what # and b are used when.
![circle](img/circle.jpg)

### For major scales progressions-this logic is applied.
![major](img/major.png)


### For minor scales progressions-this logic is applied.
![minor](img/minor.png)