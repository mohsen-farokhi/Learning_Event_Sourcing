using EventStore.ClientAPI;

namespace Framework.Persistence.ES
{
    internal static class EventStreamReader
    {
        public static async Task<IList<ResolvedEvent>> Read
            (IEventStoreConnection connection, string streamId,int start,int end)
        {
            var streamEvents = new List<ResolvedEvent>();

            StreamEventsSlice currentSlice;
            var nextSliceStart = start;

            do
            {
                currentSlice =
                    await connection.ReadStreamEventsForwardAsync
                    (streamId, nextSliceStart, end, false);

                nextSliceStart = (int)currentSlice.NextEventNumber;

                streamEvents.AddRange(currentSlice.Events);

            } while (!currentSlice.IsEndOfStream);

            return streamEvents;
        }
    }

}