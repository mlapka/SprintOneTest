﻿CREATE PROCEDURE spSelectAllEventItems
AS
	SELECT *
	FROM EventItem
	WHERE Active = 1
	RETURN @@ROWCOUNT