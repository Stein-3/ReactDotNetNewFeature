import useCounter from "./useCounter";

const Counter: React.FC = () => {
  const { count, increment, recoilCount, recoilIncrement } = useCounter();

  return (
    <>
      <div>{count}</div>
      <button onClick={increment}>Increment</button>
      <div>{recoilCount}</div>
      <button onClick={recoilIncrement}>Increment</button>
    </>
  );
};

export default Counter;
