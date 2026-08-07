/*
 * This file holds the unit tests for the RentableItem class: the checks that a
 * catalogued piece of gear starts out with the identifier, name, and daily rate
 * it was constructed with, that a brand-new item is reported as available rather
 * than rented, and that each mutator updates the value its accessor reports.
 * These tests run under xUnit against MyApp.Core; run `dotnet test` to execute
 * them.
 *
 * Robert Sterenchak
 * August 7, 2026
 */

using MyApp.Core;

namespace MyApp.Tests;

public class RentableItemTests
{
    //Test that the constructor stores the identifier, name, and rate it is given.
    [Fact]
    public void ConstructorStoresSuppliedFields()
    {
        RentableItem item = new RentableItem("TENT-01", "Two-Person Tent", 24.50m);//build an item with known field values

        Assert.Equal("TENT-01", item.getItemId());//identifier is stored verbatim
        Assert.Equal("Two-Person Tent", item.getName());//display name is stored verbatim
        Assert.Equal(24.50m, item.getDailyRate());//daily rate is stored verbatim
    }//end of ConstructorStoresSuppliedFields

    //Test that a freshly constructed item reports itself as available, not rented.
    [Fact]
    public void NewItemStartsAvailable()
    {
        RentableItem item = new RentableItem("KAYAK-07", "Sea Kayak", 40.00m);//build a fresh catalogue item

        Assert.False(item.getIsRented());//a new item must start available
    }//end of NewItemStartsAvailable

    //Test that each mutator updates the value its matching accessor returns.
    [Fact]
    public void MutatorsUpdateAccessors()
    {
        RentableItem item = new RentableItem("PACK-03", "Day Pack", 8.00m);//build an item to mutate

        item.setItemId("PACK-04");//change the identifier
        item.setName("Overnight Pack");//change the display name
        item.setDailyRate(12.00m);//change the daily rate
        item.setIsRented(true);//mark the item rented out

        Assert.Equal("PACK-04", item.getItemId());//accessor reflects the new identifier
        Assert.Equal("Overnight Pack", item.getName());//accessor reflects the new name
        Assert.Equal(12.00m, item.getDailyRate());//accessor reflects the new rate
        Assert.True(item.getIsRented());//accessor reflects the new rented flag
    }//end of MutatorsUpdateAccessors
}//end of RentableItemTests
