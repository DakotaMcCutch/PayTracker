PayTracker
==========
I had to backtrack a bit due to the unforeseen compatibility issues with the variable types, but I have patched some of the holes but with every fix more holes are created some even larger then the last. 

To Do
===========
<ul>
<li>Recalculations when user adds entry before the last one</li>
<li>Auto Sorting when entry is entered</li>
<li>Create Data Page
	<ul>
	<li>DataGridView W/ All Data</li>
	<li>Non Editable Fields (all totals, and balance)</li>
	</ul></li>

</ul>
Issues
===========
<ul>
<li>Sorting the columns by date is hit and miss at time due to how the data is entered and imported from back up file</li>
<li>If entering a date thats before the last row the totals and balance will be thrown off ex. entering 1/1/14 when the last column is 1/24/15 the columns that are calculated from the last row will be thown out of wack</li>
</ul>
