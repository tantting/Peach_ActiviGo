import React, { useState } from "react";

// Activity CRUD Components
import CreateActivityView from "./CRUDSView/Activity/CreateActivityView.jsx";
import UpdateActivityView from "./CRUDSView/Activity/UpdateActivityView.jsx";

// Location CRUD Components
import CreateLocationView from "./CRUDSView/Location/CreateLocationView.jsx";
import UpdateLocationView from "./CRUDSView/Location/UpdateLocationView.jsx";
import DeleteLocationView from "./CRUDSView/Location/DeleteLocationView.jsx";

// ActivitySlot CRUD Components
import CreateActivitySlotView from "./CRUDSView/ActivitySlot/CreateActivitySlotView.jsx";
import UpdateActivitySlotView from "./CRUDSView/ActivitySlot/UpdateActivitySlotView.jsx";
import DeleteActivitySlotView from "./CRUDSView/ActivitySlot/DeleteActivitySlotView.jsx";
// ActivityLocation CRUD Components
import CreateActivityLocationView from "./CRUDSView/ActivityLocation/CreateActivityLocationView.jsx";
import GetAllActivityLocationsView from "./CRUDSView/ActivityLocation/GetAllActivityLocationsView.jsx";

// Existing Page Components
import BookingStatisticsView from "./BookingStatisticsView.jsx";
import GetAllActivitiesView from "./CRUDSView/Activity/GetAllActivitiesView.jsx";
import GetAllLocationsView from "./CRUDSView/Location/GetAllLocationsView.jsx";
import GetAllActivitySlotsView from "./CRUDSView/ActivitySlot/GetAllActivitySlotsView.jsx";
import DeleteActivityView from "./CRUDSView/Activity/DeleteActivityView.jsx";

// Styles
import "../../Styles/AdminView.css";

export default function AdminView() {
  const [selectedAction, setSelectedAction] = useState(null);

  // Navigation handlers
  const openCreate = () => setSelectedAction("create");
  const openUpdate = () => setSelectedAction("update");
  const openList = () => setSelectedAction("list");
  const openDelete = () => setSelectedAction("delete");
  const openCreateLocation = () => setSelectedAction("createLocation");
  const openUpdateLocation = () => setSelectedAction("updateLocation");
  const openListLocations = () => setSelectedAction("listLocations");
  const openDeleteLocation = () => setSelectedAction("deleteLocation");
  const openCreateActivitySlot = () => setSelectedAction("createActivitySlot");
  const openUpdateActivitySlot = () => setSelectedAction("updateActivitySlot");
  const openListActivitySlots = () => setSelectedAction("listActivitySlots");
  const openDeleteActivitySlot = () => setSelectedAction("deleteActivitySlot");
  const openCreateActivityLocation = () =>
    setSelectedAction("createActivityLocation");
  const openUpdateActivityLocation = () =>
    setSelectedAction("updateActivityLocation");
  const openListActivityLocations = () =>
    setSelectedAction("listActivityLocations");
  const openDeleteActivityLocation = () =>
    setSelectedAction("deleteActivityLocation");
  const openStatistics = () => setSelectedAction("statistics");
  const goBack = () => setSelectedAction(null);

  return (
    <div className="admin-container">
      {/* Navigation Cards */}
      <div className="card-container">
        {/* AKTIVITETER */}
        <ul className="admin-card-list">
          <p className="admin-header-title">Aktiviteter</p>
          <button className="admin-card" onClick={openCreate}>
            <span className="card-title">Lägg till aktivitet</span>
          </button>
          <button className="admin-card" onClick={openList}>
            <span className="card-title">Hämta alla aktiviteter</span>
          </button>
          <button className="admin-card" onClick={openUpdate}>
            <span className="card-title">Uppdatera aktivitet</span>
          </button>
          <button className="admin-card" onClick={openDelete}>
            <span className="card-title">Radera aktivitet</span>
          </button>
        </ul>

        {/* PLATSER */}
        <ul className="admin-card-list">
          <p className="admin-header-title">Platser</p>
          <button className="admin-card" onClick={openCreateLocation}>
            <span className="card-title">Lägg till plats</span>
          </button>
          <button className="admin-card" onClick={openListLocations}>
            <span className="card-title">Hämta alla platser</span>
          </button>
          <button className="admin-card" onClick={openUpdateLocation}>
            <span className="card-title">Uppdatera plats</span>
          </button>
          <button className="admin-card" onClick={openDeleteLocation}>
            <span className="card-title">Radera plats</span>
          </button>
        </ul>

        {/* AKTIVITETSTILLFÄLLEN */}
        <ul className="admin-card-list">
          <p className="admin-header-title">Aktivitetstillfällen</p>
          <button className="admin-card" onClick={openCreateActivitySlot}>
            <span className="card-title">Lägg till tillfälle</span>
          </button>
          <button className="admin-card" onClick={openListActivitySlots}>
            <span className="card-title">Hämta alla tillfällen</span>
          </button>
          <button className="admin-card" onClick={openUpdateActivitySlot}>
            <span className="card-title">Uppdatera tillfälle</span>
          </button>
          <button className="admin-card" onClick={openDeleteActivitySlot}>
            <span className="card-title">Radera tillfälle</span>
          </button>
        </ul>

        {/* AKTIVITET-PLATSER */}
        <ul className="admin-card-list">
          <p className="admin-header-title">Aktivitet-platser</p>
          <button className="admin-card" onClick={openCreateActivityLocation}>
            <span className="card-title">Lägg till aktivitet-plats</span>
          </button>
          <button className="admin-card" onClick={openListActivityLocations}>
            <span className="card-title">Hämta alla aktivitet-platser</span>
          </button>
          <button className="admin-card" onClick={openUpdateActivityLocation}>
            <span className="card-title">Uppdatera aktivitet-plats</span>
          </button>
          <button className="admin-card" onClick={openDeleteActivityLocation}>
            <span className="card-title">Radera aktivitet-plats</span>
          </button>
        </ul>

        {/* STATISTIK */}
        <ul className="admin-card-list">
          <p className="admin-header-title">Övrigt</p>
          <button className="admin-card-statistics" onClick={openStatistics}>
            <span className="card-title">Statistik</span>
          </button>
        </ul>
      </div>

      {/* Dynamic Content Based on Selected Action */}
      {selectedAction === "create" && <CreateActivityView onBack={goBack} />}
      {selectedAction === "update" && <UpdateActivityView onBack={goBack} />}
      {selectedAction === "list" && (
        <section className="action-panel">
          <div className="panel-header">
            <h2>Alla aktiviteter</h2>
            <p>Visar hela listan från API:t.</p>
          </div>
          <GetAllActivitiesView
            showTitle={false}
            containerClassName="statistics-embedded"
          />
          <div className="panel-actions">
            <button type="button" className="btn ghost" onClick={goBack}>
              Tillbaka
            </button>
          </div>
        </section>
      )}
      {selectedAction === "delete" && (
        <section className="action-panel">
          <div className="panel-header">
            <h2>Radera aktivitet</h2>
            <p>Ange ID och radera aktiviteten.</p>
          </div>
          <DeleteActivityView
            showTitle={false}
            containerClassName="statistics-embedded"
          />
          <div className="panel-actions">
            <button type="button" className="btn danger" onClick={goBack}>
              Tillbaka
            </button>
          </div>
        </section>
      )}

      {selectedAction === "createLocation" && (
        <CreateLocationView onBack={goBack} />
      )}
      {selectedAction === "updateLocation" && (
        <UpdateLocationView onBack={goBack} />
      )}
      {selectedAction === "listLocations" && (
        <section className="action-panel">
          <div className="panel-header">
            <h2>Alla platser</h2>
            <p>Visar hela listan från API:t.</p>
          </div>
          <GetAllLocationsView
            showTitle={false}
            containerClassName="statistics-embedded"
          />
          <div className="panel-actions">
            <button type="button" className="btn ghost" onClick={goBack}>
              Tillbaka
            </button>
          </div>
        </section>
      )}
      {selectedAction === "deleteLocation" && (
        <DeleteLocationView onBack={goBack} />
      )}

      {selectedAction === "createActivitySlot" && (
        <CreateActivitySlotView onBack={goBack} />
      )}
      {selectedAction === "updateActivitySlot" && (
        <UpdateActivitySlotView onBack={goBack} />
      )}
      {selectedAction === "listActivitySlots" && (
        <section className="action-panel">
          <div className="panel-header">
            <h2>Alla aktivitetstillfällen</h2>
            <p>Visar hela listan från API:t.</p>
          </div>
          <GetAllActivitySlotsView
            showTitle={false}
            containerClassName="statistics-embedded"
          />
          <div className="panel-actions">
            <button type="button" className="btn ghost" onClick={goBack}>
              Tillbaka
            </button>
          </div>
        </section>
      )}
      {selectedAction === "deleteActivitySlot" && (
        <DeleteActivitySlotView onBack={goBack} />
      )}

      {selectedAction === "createActivityLocation" && (
        <CreateActivityLocationView onBack={goBack} />
      )}
      {selectedAction === "listActivityLocations" && (
        <section className="action-panel">
          <div className="panel-header">
            <h2>Alla aktivitet-platser</h2>
            <p>Visar hela listan från API:t.</p>
          </div>
          <GetAllActivityLocationsView
            showTitle={false}
            containerClassName="statistics-embedded"
          />
          <div className="panel-actions">
            <button type="button" className="btn ghost" onClick={goBack}>
              Tillbaka
            </button>
          </div>
        </section>
      )}

      {selectedAction === "statistics" && (
        <section className="action-panel">
          <BookingStatisticsView
            showTitle={false}
            containerClassName="statistics-embedded"
          />
          <div className="panel-actions">
            <button type="button" className="btn ghost" onClick={goBack}>
              Tillbaka
            </button>
          </div>
        </section>
      )}
    </div>
  );
}
