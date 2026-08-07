/*
 * This file holds the unit tests for the Catalog class: the checks that a fresh
 * catalog starts empty, that an added item can be found again by its identifier,
 * that looking up an identifier the catalog does not stock returns a not-found
 * result rather than throwing, and that the listing reports every item added
 * without letting a caller mutate the catalog's own collection. These tests run
 * under xUnit against MyApp.Core; run `dotnet test` to execute them.
 *
 * Robert Sterenchak
 * August 7, 2026
 */

using MyApp.Core;

namespace MyApp.Tests;

public class CatalogTests
{
    //Test that a newly constructed catalog holds no items.
    [Fact]
    public void NewCatalogStartsEmpty()
    {
        Catalog catalog = new Catalog();//build a fresh, empty catalog

        Assert.Empty(catalog.listItems());//a new catalog stocks nothing yet
    }//end of NewCatalogStartsEmpty

    //Test that an added item can be looked up again by its identifier.
    [Fact]
    public void AddedItemCanBeFoundById()
    {
        Catalog catalog = new Catalog();//build a catalog to add to
        RentableItem tent = new RentableItem("TENT-01", "Two-Person Tent", 24.50m);//an item to stock

        catalog.addItem(tent);//add the item to the catalog

        RentableItem? found = catalog.findItem("TENT-01");//look the item up by its identifier
        Assert.NotNull(found);//the stocked item must be found
        Assert.Equal("Two-Person Tent", found!.getName());//and it is the same item that was added
    }//end of AddedItemCanBeFoundById

    //Test that looking up an unstocked identifier returns null instead of throwing.
    [Fact]
    public void MissingItemLookupReturnsNull()
    {
        Catalog catalog = new Catalog();//build a catalog with one unrelated item
        catalog.addItem(new RentableItem("KAYAK-07", "Sea Kayak", 40.00m));//stock a single item

        RentableItem? found = catalog.findItem("NONE-99");//look up an identifier that is not stocked

        Assert.Null(found);//a miss reports null rather than throwing
    }//end of MissingItemLookupReturnsNull

    //Test that the listing reports every item that was added to the catalog.
    [Fact]
    public void ListItemsReportsEveryAddedItem()
    {
        Catalog catalog = new Catalog();//build a catalog to fill
        catalog.addItem(new RentableItem("TENT-01", "Two-Person Tent", 24.50m));//first item
        catalog.addItem(new RentableItem("KAYAK-07", "Sea Kayak", 40.00m));//second item

        IReadOnlyList<RentableItem> listed = catalog.listItems();//pull the full listing

        Assert.Equal(2, listed.Count);//every added item appears in the listing
    }//end of ListItemsReportsEveryAddedItem

    //Test that the listing is a snapshot the caller cannot use to mutate the catalog.
    [Fact]
    public void ListItemsSnapshotDoesNotAffectCatalog()
    {
        Catalog catalog = new Catalog();//build a catalog with one item
        catalog.addItem(new RentableItem("PACK-03", "Day Pack", 8.00m));//stock a single item

        IReadOnlyList<RentableItem> listed = catalog.listItems();//take a snapshot of the listing
        ((List<RentableItem>)listed).Add(new RentableItem("EXTRA-01", "Sneaked In", 1.00m));//mutate the returned copy

        Assert.Single(catalog.listItems());//the catalog's own contents are unchanged
    }//end of ListItemsSnapshotDoesNotAffectCatalog
}//end of CatalogTests
