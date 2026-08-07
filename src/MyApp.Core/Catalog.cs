/*
 * This file defines the catalog of rentable gear for Ridgeline Outfitters: the
 * collection the counter staff work from to add new equipment, pull up a single
 * item by its identifier, and review everything on the books. It holds a list of
 * RentableItem (RentableItem.cs) and exposes an add operation, a by-identifier
 * lookup that reports a miss instead of throwing, and a read-only listing of all
 * items. A lookup for an identifier that is not stocked returns null so callers
 * can decide what to do rather than handle an exception.
 *
 * Robert Sterenchak
 * August 7, 2026
 */

namespace MyApp.Core;

public class Catalog
{
    //instance variables
    private List<RentableItem> items = new List<RentableItem>();//every rentable item currently on the books

    /** Constructors */

    //Constructor that starts an empty catalog ready for items to be added.
    public Catalog()
    {
        this.items = new List<RentableItem>();//begin with no items stocked
    }//ends constructor

    /** Accessor Methods */

    //Get function returns the item with the given identifier, or null when none is stocked.
    public RentableItem? findItem(string itemId)
    {
        int counter = 0;//index into the items list

        /*Walks the stocked items looking for one whose identifier matches the request, stopping at the first hit.*/
        while (counter < this.items.Count)
        {
            RentableItem candidate = this.items[counter];//item currently under inspection

            if (candidate.getItemId() == itemId)
            {//checks whether this item is the one being looked up
                return candidate;//found the requested item
            }//end if

            counter = counter + 1;//advance to the next stocked item
        }//end while loop

        return null;//no item carried the requested identifier
    }//end of findItem

    //Get function returns a read-only snapshot of every item in the catalog.
    public IReadOnlyList<RentableItem> listItems()
    {
        return new List<RentableItem>(this.items);//copy so callers cannot mutate the catalog's own list
    }//end of listItems

    /** Mutator Methods */

    //Set function adds a rentable item to the catalog.
    public void addItem(RentableItem newItem)
    {
        this.items.Add(newItem);//store the item on the books
    }//end of addItem
}//end of Catalog
