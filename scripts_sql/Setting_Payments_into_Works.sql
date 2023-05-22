USE GuardsEarnings;

--it's selected all works of a particular Guard, related to one especific month
SELECT G.GuardId, G.Name as 'Guard', T.Name as 'Target',W.WorkId, W.Payment, J.Date FROM dbo.Works W
	INNER JOIN dbo.Guards G
	ON G.Name = 'Diego'
		INNER JOIN dbo.Targets T
		ON T.TargetId = W.TargetId
			INNER JOIN dbo.Journeys J
			ON J.JourneyId = W.JourneyId AND J.Date LIKE '%2023-%' 
			WHERE W.GuardId = G.GuardId AND W.TargetId = T.TargetId AND W.JourneyId = J.JourneyId;


--Testing before of apply update
BEGIN TRAN
	UPDATE dbo.Works SET Payment = 180
	FROM dbo.Works W INNER JOIN dbo.Guards G ON G.Name = 'Diego'
		INNER JOIN dbo.Targets T ON T.TargetId = W.TargetId
			INNER JOIN dbo.Journeys J ON J.JourneyId = W.JourneyId AND J.Date LIKE '%2023-05%'
			WHERE W.GuardId = G.GuardId AND W.TargetId = T.TargetId AND W.JourneyId = J.JourneyId;
				


	SELECT G.GuardId, G.Name as 'Guard', T.Name as 'Target',W.WorkId, W.Payment, J.Date FROM dbo.Works W
		INNER JOIN dbo.Guards G
		ON G.Name = 'Diego'
			INNER JOIN dbo.Targets T
			ON T.TargetId = W.TargetId
				INNER JOIN dbo.Journeys J
				ON J.JourneyId = W.JourneyId  
				WHERE W.GuardId = G.GuardId AND W.TargetId = T.TargetId AND W.JourneyId = J.JourneyId;
ROLLBACK TRAN --Undo the update
--COMMIT TRAN --Apply the update