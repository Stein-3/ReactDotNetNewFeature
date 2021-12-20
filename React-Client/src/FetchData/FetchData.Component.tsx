import { Suspense } from "react";
import useFetchData from "./UseFetchData";

const FetchData: React.FC = () => {
  return (
    <Suspense fallback={<h1>Loading ...</h1>}>
      <FetchDataTable />
    </Suspense>
  );
};

const FetchDataTable: React.FC = () => {
  const wetherForecasts = useFetchData();

  return (
    <table>
      <thead>
        <tr>
          <th>Date</th>
          <th>Temp. (C)</th>
          <th>Temp. (F)</th>
          <th>summary</th>
        </tr>
      </thead>
      <tbody>
        {wetherForecasts.map((each) => {
          <tr>
            <td>{each.Date}</td>
            <td>{each.TemperatureC}</td>
            <td>{each.TemperatureF}</td>
            <td>{each.Summary}</td>
          </tr>;
        })}
      </tbody>
    </table>
  );
};

export default FetchData;
